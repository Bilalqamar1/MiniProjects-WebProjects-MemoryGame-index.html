#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_PROCESSES 10
#define MAX_MEMORY 1024

typedef enum {
    READY,
    RUNNING,
    TERMINATED
} ProcessState;

typedef struct {
    int pid;
    int memory;
    ProcessState state;
} Process;

/* ---------- Global system state ---------- */
Process* processes[MAX_PROCESSES];
int process_count = 0;
int used_memory = 0;

/* ---------- Utility ---------- */
const char* state_to_string(ProcessState state) {
    switch (state) {
        case READY: return "READY";
        case RUNNING: return "RUNNING";
        case TERMINATED: return "TERMINATED";
        default: return "UNKNOWN";
    }
}

/* ---------- Memory management ---------- */
int allocate_memory(int amount) {
    if (used_memory + amount > MAX_MEMORY) {
        return 0;
    }
    used_memory += amount;
    return 1;
}

void free_memory(int amount) {
    used_memory -= amount;
    if (used_memory < 0) used_memory = 0;
}

/* ---------- Process management ---------- */
void create_process(int memory) {
    if (process_count >= MAX_PROCESSES) {
        printf("❌ Max number of processes reached\n");
        return;
    }

    if (!allocate_memory(memory)) {
        printf("❌ Not enough memory to create process\n");
        return;
    }

    Process* p = malloc(sizeof(Process));
    p->pid = process_count + 1;
    p->memory = memory;
    p->state = READY;

    processes[process_count++] = p;
    printf("✅ Process %d created (%d MB)\n", p->pid, memory);
}

void terminate_process(int pid) {
    for (int i = 0; i < process_count; i++) {
        if (processes[i]->pid == pid && processes[i]->state != TERMINATED) {
            processes[i]->state = TERMINATED;
            free_memory(processes[i]->memory);
            free(processes[i]);
            printf("🛑 Process %d terminated\n", pid);
            return;
        }
    }
    printf("❌ Process not found\n");
}

/* ---------- Scheduler ---------- */
void run_scheduler() {
    printf("\n⚙️ Running scheduler (Round Robin)\n");
    for (int i = 0; i < process_count; i++) {
        if (processes[i] && processes[i]->state == READY) {
            processes[i]->state = RUNNING;
            printf("▶️ Process %d running\n", processes[i]->pid);
            processes[i]->state = READY;
        }
    }
}

/* ---------- System status ---------- */
void show_status() {
    printf("\n📊 SYSTEM STATUS\n");
    printf("Memory: %d / %d MB\n", used_memory, MAX_MEMORY);
    printf("Processes:\n");

    for (int i = 0; i < process_count; i++) {
        if (processes[i]) {
            printf("PID %d | %s | %d MB\n",
                   processes[i]->pid,
                   state_to_string(processes[i]->state),
                   processes[i]->memory);
        }
    }
}

/* ---------- Main ---------- */
int main() {
    int choice, memory, pid;

    while (1) {
        printf("\n=== MiniOS Simulator ===\n");
        printf("1. Create process\n");
        printf("2. Run scheduler\n");
        printf("3. Terminate process\n");
        printf("4. Show system status\n");
        printf("5. Exit\n");
        printf("Choice: ");
        scanf("%d", &choice);

        switch (choice) {
            case 1:
                printf("Memory needed (MB): ");
                scanf("%d", &memory);
                create_process(memory);
                break;

            case 2:
                run_scheduler();
                break;

            case 3:
                printf("Process ID: ");
                scanf("%d", &pid);
                terminate_process(pid);
                break;

            case 4:
                show_status();
                break;

            case 5:
                printf("👋 Shutting down MiniOS\n");
                return 0;

            default:
                printf("❌ Invalid choice\n");
        }
    }
}
